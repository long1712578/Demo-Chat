import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class ChatService {

  constructor(private route: Router, private http: HttpClient) { }
  getMessage(): Observable<any> {
  return this.http.get(`${environment.apiUrl.chatUrl}api/v1/messages`);
  }
}
