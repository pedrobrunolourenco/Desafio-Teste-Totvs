import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppComponent } from './app.component';
import { VagasComponent } from './vagas/vagas.component';
import { VagaComponent } from './vagas/vaga/vaga.component';
import { MatConfirmDialogComponent } from './mat-confirm-dialog/mat-confirm-dialog.component';
import { MaterialModule } from './material/material.module';
import { ReactiveFormsModule, FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { VagaService } from './shared/vaga.service';
import { MAT_DATE_LOCALE } from '@angular/material';
import { VagaListComponent } from './vagas/vaga-list/vaga-list.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';

@NgModule({
  declarations: [
    AppComponent,
    VagasComponent,
    VagaComponent,
    MatConfirmDialogComponent,
    VagaListComponent
  ],
  imports: [
    BrowserModule,
    MaterialModule,
    BrowserAnimationsModule,
    ReactiveFormsModule,
    HttpClientModule,
    FormsModule
  ],
  providers: [VagaService,
    { provide: MAT_DATE_LOCALE, useValue: 'pt-BR' }
  ],
  bootstrap: [AppComponent],
  entryComponents: [VagaComponent, MatConfirmDialogComponent]
})
export class AppModule { }


