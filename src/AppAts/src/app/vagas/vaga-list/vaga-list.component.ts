import { Component, OnInit, ViewChild } from '@angular/core';
import { MatDialog, MatDialogConfig, MatPaginator, MatSort, MatTableDataSource } from '@angular/material';
import { Subscription, Observable } from 'rxjs';
import { DialogService } from 'src/app/shared/dialog.service';
import { NotificationService } from 'src/app/shared/notification.service';
import { VagasModel } from 'src/app/models/VagasModel';
import { VagaService } from 'src/app/shared/vaga.service';
import { LocalStorageService } from 'src/app/shared/local-storage.service';
import { VagaComponent } from '../vaga/vaga.component';


@Component({
  selector: 'app-vaga-list',
  templateUrl: './vaga-list.component.html',
  styleUrls: ['./vaga-list.component.scss']
})
export class VagaListComponent implements OnInit {
  private subscriptions$: Subscription[] = [];

  listaDados: VagasModel[];

  public displayedColumns: string[] = [
    'posicao',
    'dataAbertura',
    'empresaContratante',
    'cargo',
    'salario',
    'options'
  ];

  @ViewChild(MatSort, { static: true }) sort: MatSort;
  @ViewChild(MatPaginator, { static: true }) paginator: MatPaginator;

  listaData: MatTableDataSource<any>;
  searchKey: string;

  constructor(public service: VagaService,
    private localStorageService: LocalStorageService,
    private dialog: MatDialog,
    public notificacoes: NotificationService,
    private dialogSerivce: DialogService,
  ) { }

  sub1: any;
  public token$: Observable<any>;

  ngOnInit() {
    this.sub1 = this.service.gerarToken().subscribe((data) => {
      console.log("------------------------");
      console.log(data);
      if (data.retorno != "Erro") {
        this.localStorageService.setSession('TOKEN', { token: data.retorno });
        this.service.validaToken();
        this.token$ = this.service.token$;
        this.obterVagas();
      }
    });
  }

  obterVagas() {
    this.subscriptions$.push(this.service.ObterVagas().subscribe(
      data => {
        console.log(data);
        this.listaData = new MatTableDataSource(data);
        this.listaData.sort = this.sort;
        this.listaData.paginator = this.paginator;
      },
      (erro) => {
        this.notificacoes.erros(":( Erro na requisição de obter vagas.")
      }
    ));
  }

  ngOnDestroy(): void {
    if (this.sub1) this.sub1.unsubscribe();
    this.subscriptions$.forEach(sub => sub.unsubscribe());
  }

  onPesquisaClear() {
    this.searchKey = "";
    this.applyFilter();
  }

  applyFilter() {
    this.listaData.filter = this.searchKey.trim().toLowerCase();
  }



  onEdit(id){
		this.obterVagaPorId(id)
	}

	onCreate(){
        const dialogConfig = new MatDialogConfig();
		dialogConfig.disableClose = true;
		dialogConfig.autoFocus = true;
		dialogConfig.width = "70%";
		this.service.incioFormulario();
		this.dialog.open(VagaComponent,dialogConfig).afterClosed().subscribe(result => {
			this.obterVagas();
		});
	}

	onDelete(id){
		this.dialogSerivce.openConfirmDialog("Você tem certeza que deseja excluir esta vaga?")
		.afterClosed().subscribe(res => {
			if(res)
			{
				this.excluirVaga(id);
			}
		});
	}

	excluirVaga(id)
	{
		this.subscriptions$.push(this.service .ExcluirVaga(id).subscribe(
			data => {
				if(data)
				{
					this.notificacoes.sucess("Vaga excluída com sucesso!");
					this.obterVagas();
				}
				else
				{
					this.notificacoes.erros(":( Vaga não localizada.")
				}
			},
			(erro) => {
				this.notificacoes.erros(":( Erro na requisição de obter Vagas.")
			}
		));
	}

  obterVagaPorId(id) {
		this.subscriptions$.push(this.service.ObterVagaPorId(id).subscribe(
			data => {
				const dialogConfig = new MatDialogConfig();
				dialogConfig.disableClose = true;
				dialogConfig.autoFocus = true;
				dialogConfig.width = "70%";
				this.service.editFormulario(data);
				this.dialog.open(VagaComponent,dialogConfig).afterClosed().subscribe(result => {
					this.obterVagas();
				});

			},
			(erro) => {
				this.notificacoes.erros(":( Vaga não foi localizada.")
			}
		));

	}



}

