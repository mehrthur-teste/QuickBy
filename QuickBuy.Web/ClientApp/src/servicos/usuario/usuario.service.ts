
//
import { Injectable, Inject } from "@angular/core";
//para as requisições
import { HttpClient, HttpHeaders } from "@angular/common/http";
//
import { Observable } from "rxjs";
import { Usuarios } from "../../app/modelo/usuario";


// significa que a gente pode trabalhar com qualquer classe

@Injectable({
    providedIn: "root"
})

export class UsuarioServico {

    private baseURL: string;
    private _usuario: Usuarios;

    get usuario(): Usuarios {
        let usuario_Json = sessionStorage.getItem("usuario-autenticado");
        this._usuario = JSON.parse(usuario_Json);
        return this._usuario;
    }

    set usuario(usuario: Usuarios) {
        sessionStorage.setItem("usuario-autenticado", JSON.stringify(usuario));
        this._usuario = usuario;
    }

  public usuario_autenticado(): boolean {
    return this._usuario != null && this._usuario.email != "" && this._usuario.senha != "";
    
  }

    public usuario_Administrador(): boolean {
      return this.usuario_autenticado() && this.usuario.ehAdministrador;
  }

    public limpar_sessao() {
        sessionStorage.setItem("usuario-autenticado", "");
        this._usuario = null;
    }

    get headers(): HttpHeaders {
        return new HttpHeaders().set('content-type', 'application/json');;
    }


    constructor(private http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
        this.baseURL = baseUrl;
    }

    public verificarUsuario(usuario: Usuarios): Observable<Usuarios> {

        const headers = new HttpHeaders().set('content-type','application/json');

        var body = {
            email: usuario.email,
            senha: usuario.senha
        }
        //VerificarUsuario
        return this.http.post<Usuarios>(this.baseURL + "api/usuario/VerificarUsuario", body, { headers });
        //return this.http.get<Usuarios>(this.baseURL + "api/usuario", body, { headers });
    }

    public cadastrarUsuario(usuario: Usuarios): Observable<Usuarios> {

        //const headers = new HttpHeaders().set('content-type', 'application/json');

  
        return this.http.post<Usuarios>(this.baseURL + "api/usuario", JSON.stringify(usuario), { headers: this.headers })

    }

}


