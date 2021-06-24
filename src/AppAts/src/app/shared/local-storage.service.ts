import { Injectable } from '@angular/core';
import { HttpHeaders } from '@angular/common/http';

const APP_PREFIX = 'ATS-';

@Injectable({
	providedIn: 'root'
})
export class LocalStorageService {
	constructor() {}

	setItem(key: string, value: any) {
		localStorage.setItem(`${APP_PREFIX}${key}`, JSON.stringify(value));
	}

	getItem(key: string) {
		return JSON.parse(localStorage.getItem(`${APP_PREFIX}${key}`));
	}

	removeItem(key: string) {
		localStorage.removeItem(`${APP_PREFIX}${key}`);
	}

	setSession(key: string, value: any) {
		sessionStorage.setItem(`${APP_PREFIX}${key}`, JSON.stringify(value));
	}

	getSession(key: string) {
		return JSON.parse(sessionStorage.getItem(`${APP_PREFIX}${key}`));
	}

	removeSession(key: string) {
		sessionStorage.removeItem(`${APP_PREFIX}${key}`);
	}
	

	ObterHeader() {
		return {
		  headers: new HttpHeaders({
			'Content-Type': 'application/json',
			'Authorization': `Bearer ${this.getSession("TOKEN").token}`
		  })
		};
	  }
}
