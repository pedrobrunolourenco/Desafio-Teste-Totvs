import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { environment } from 'src/environments/environment';
import { take } from 'rxjs/operators';
import { VagasModel } from '../models/VagasModel';
import { LocalStorageService } from './local-storage.service';
import { BehaviorSubject } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class VagaService {
  public token$: BehaviorSubject<boolean>;


  constructor(private http: HttpClient,
    private localStorage: LocalStorageService) {
    if (!this.token$) {
      this.token$ = new BehaviorSubject<any>(null);
    }
  }

  validaToken() {
    return this.token$.next(true);
  }

  invalidaToken() {
    return this.token$.next(null);
  }

  public formulario: FormGroup = new FormGroup({
    Id: new FormControl('0'),
    EmpresaContratante: new FormControl('', [Validators.required, Validators.maxLength(100)]),
    Locacao: new FormControl('', [Validators.required, Validators.maxLength(100)]),
    DataAbertura: new FormControl('', [Validators.required]),
    Status: new FormControl('', [Validators.required, Validators.minLength(1), Validators.maxLength(1)]),
    Cargo: new FormControl('', [Validators.required, Validators.maxLength(100)]),
    DescricaoVaga: new FormControl('', [Validators.required, Validators.minLength(30), Validators.maxLength(4000)]),
    InglesFluente: new FormControl(false, [Validators.required]),
    Graduacao: new FormControl(false, [Validators.required]),
    Genero: new FormControl('', [Validators.required, Validators.minLength(1), Validators.maxLength(1)]),
    Observacao: new FormControl('', [Validators.required, Validators.maxLength(200)]),
    Salario: new FormControl('0,00')
  });

  incioFormulario() {
    this.formulario.setValue({
      Id: '0',
      EmpresaContratante: '',
      Locacao: '',
      DataAbertura: '',
      Status: 'A',
      Cargo: '',
      DescricaoVaga: '',
      InglesFluente: false,
      Graduacao: false,
      Genero: 'I',
      Observacao: '',
      Salario: '0,00'
    })
  }

  editFormulario(vaga: any) {
    this.formulario.setValue({
      Id: vaga.id,
      EmpresaContratante: vaga.empresaContratante,
      Locacao: vaga.locacao,
      DataAbertura: vaga.dataAbertura,
      Status: vaga.status,
      Cargo: vaga.cargo,
      DescricaoVaga: vaga.descricaoVaga,
      InglesFluente: vaga.inglesFluente,
      Graduacao: vaga.graduacao,
      Genero: vaga.genero,
      Observacao: vaga.observacao,
      Salario: vaga.salario.toLocaleString('pt-br', { minimumFractionDigits: 2 })
    })
  }

  gerarToken() {
    let login = {
      login: "ATS"
    };
    return this.http.post<any>(environment.URL_BASE + "Seguranca" + "/Gerar-Token", login).pipe(
      take(1)
    );
  }


  ObterVagas() {
    return this.http.get<any[]>(environment.URL_BASE + "Vagas" + "/Obter-Lista", this.localStorage.ObterHeader())
      .pipe(
        take(2)
      );
  }

  IncluirVaga(vaga: any) {
    return this.http.post<any>(environment.URL_BASE + "Vagas/Adicionar", vaga, this.localStorage.ObterHeader())
      .pipe(
        take(2)
      );
  }

  AlterarVaga(vaga: any) {
    return this.http.put<any>(environment.URL_BASE + "Vagas/Alterar/", vaga, this.localStorage.ObterHeader())
      .pipe(
        take(2)
      );
  }

  ObterVagaPorId(id) {
    return this.http.get<VagasModel[]>(environment.URL_BASE + "Vagas/Obter-Por-Id?id=" + id,this.localStorage.ObterHeader())
      .pipe(
        take(2)
      );
  }

  ExcluirVaga(id) {
		return this.http.delete<any>(environment.URL_BASE + "Vagas/Excluir?id=" + id, this.localStorage.ObterHeader() )
			.pipe(
				take(2)
			);
	}


}
