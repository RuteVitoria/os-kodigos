import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class OrdemServicoService {
  private apiUrl = 'http://localhost:5008/api/OrdemServico';

  constructor(private http: HttpClient) {}

  enviarOrdemServico(payload: any): Observable<any> {
    return this.http.post(this.apiUrl, payload);
  }
}
