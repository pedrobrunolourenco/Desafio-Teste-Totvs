import { Component, OnInit } from '@angular/core';
import { VagaService } from 'src/app/shared/vaga.service';
import { JsService } from 'src/app/shared/js.service';
import { MatDialogRef } from '@angular/material';
import { NotificationService } from 'src/app/shared/notification.service';
import { Subscription } from 'rxjs';

@Component({
  selector: 'app-vaga',
  templateUrl: './vaga.component.html',
  styleUrls: ['./vaga.component.scss']
})
export class VagaComponent implements OnInit {

  private subscriptions$: Subscription[] = [];

  acao: string;
  salvaVaga: any;

  constructor(public service: VagaService,
    public js: JsService,
    public dialogRef: MatDialogRef<VagaComponent>,
    public notificacoes: NotificationService) { }

    onClose() {
      this.service.formulario.reset();
      this.service.incioFormulario();
      this.dialogRef.close();
    }
  
  ngOnInit() {
    this.acao = "I";
    if(this.service.formulario.value.Id != "0" && this.service.formulario.value.Id != undefined)
    {
       this.acao = "A";
       this.salvaVaga = this.service.formulario.value;
       
    }
  }

  onSubmit() {

    if (this.service.formulario.valid) {
      if(this.service.formulario.value.Id == "0" || this.service.formulario.value.Id == undefined)
      {
        var valorFormatado = (<HTMLInputElement>document.getElementById("valorFormatado")).value;
        this.service.formulario.value.Salario = parseFloat(this.js.MoedaToNumber(valorFormatado)); 
        this.service.IncluirVaga(this.service.formulario.value)

        .subscribe(data => {
          if (data && data.listaErros.length <= 0) {
            this.notificacoes.sucess(":) Inclusão realizada com sucesso!")
            this.onClose();
          }
          else {
            let msg = ":( ";
            data.listaErros.forEach(e => {
              msg += e + "\n :( ";
            });
            this.notificacoes.erros(msg);
          }
        });
      }

      if(this.service.formulario.value.Id != "0" && this.service.formulario.value.Id != undefined)
      {
        var valorFormatado = (<HTMLInputElement>document.getElementById("valorFormatado")).value;
        this.service.formulario.value.Salario = parseFloat(this.js.MoedaToNumber(valorFormatado));
        this.service.AlterarVaga(this.service.formulario.value)
        .subscribe(data => {
          if (data && data.listaErros.length <= 0) {
            this.notificacoes.sucess(":) Alteração realizada com sucesso!")
            this.onClose();
          }
          else {
            let msg = " :( ";
            data.listaErros.forEach(e => {
              msg += e + "\n :( ";
            });
            this.notificacoes.erros(msg);
          }
        });
      }
    }
  }

  onClear() {
    if(this.acao == "I")
    {
      this.service.formulario.reset();
      this.service.incioFormulario();
    }

    if(this.acao == "A")
    {
      this.service.editFormulario(this.salvaVaga);
    }

  }


  ngOnDestroy(): void {
    this.subscriptions$.forEach(sub => sub.unsubscribe());
  }





}
