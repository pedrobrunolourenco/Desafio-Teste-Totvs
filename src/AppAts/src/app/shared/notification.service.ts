import { Injectable } from '@angular/core';
import { MatSnackBar, MatSnackBarConfig } from '@angular/material';

@Injectable({
  providedIn: 'root'
})



export class NotificationService {


  constructor(public snackBar: MatSnackBar) { }

  config: MatSnackBarConfig = {
    duration: 3000,
    horizontalPosition: 'right',
    verticalPosition: 'top'
  }

  configerro: MatSnackBarConfig = {
    duration: 10000,
    verticalPosition: 'top'
  }


  sucess(msg) {
    this.config['panelClass'] = ['notification', 'success'];
    this.snackBar.open(msg, '', this.config);
  }

  warn(msg) {
    this.config['panelClass'] = ['notification', 'warn'];
    this.snackBar.open(msg, '', this.config);
  }

  erros(msg) {
    this.configerro['panelClass'] = ['notification', 'erros'];
    this.snackBar.open(msg, '', this.configerro);
  }

}