import { HttpClient } from '@angular/common/http';
import { inject,Injectable } from '@angular/core';
import { Auth_Token } from '../data/intarfaces/auth.interface';

@Injectable({
  providedIn: 'root'
})
export class AuthService {
  http: HttpClient = inject(HttpClient)

  baseapiURL: string = 'https://localhost:7260/Auth?IndividualNumber='

  login(username: number, password: string) {
    this.baseapiURL += username.toString()+'&password='+password
    console.log(this.baseapiURL)
    return this.http.get<Auth_Token>(`${this.baseapiURL}`)
  }
}
