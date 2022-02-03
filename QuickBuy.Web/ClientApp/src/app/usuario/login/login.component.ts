import { Component, OnInit } from "@angular/core";
import { Usuarios } from "../../modelo/usuario";
//adicionar o router
import { Router, ActivatedRoute } from "@angular/router";
import { UsuarioServico } from "../../../servicos/usuario/usuario.service";


@Component({

    selector: "app-login",
    templateUrl: "./login.component.html",
    styleUrls:["./login.component.css"]
})

export class LoginComponent implements OnInit{
    
    public usuario;
    public returnUrl: string;
    public mensagem;
    public ativar_spinner: boolean;

    constructor(private router: Router, private activatedRouter: ActivatedRoute,
        private usuarioServico: UsuarioServico) {
        
    }

    ngOnInit(): void {

        //este método faz parte do ciclo de vida de du componente
        this.usuario = new Usuarios();
        //buscar o valor de return url que está  no guarda rotas
        this.returnUrl = this.activatedRouter.snapshot.queryParams['returnUrl'];
    }

    entrar(): void{
        this.ativar_spinner = true;

        this.usuarioServico.verificarUsuario(this.usuario)
            .subscribe(
                usuario_Json => {
                    //será executada de retorno sem erros
                 
                    this.usuarioServico.usuario = usuario_Json;
                    //para navegar na página certa
                    if (this.returnUrl == null) {
                        this.router.navigate(['/']);
                    }
                    else {
                        this.router.navigate([this.returnUrl]);
                    }
                },
                err => {
                    // console.log(err.error);
                    this.mensagem = err.error;
                    this.ativar_spinner = false;
                },
            );
        /*
        if (this.usuario.email == "leo@teste.com" && this.usuario.senha=="abc123") {

            //localstorage e session storage é um recurso do html
            sessionStorage.setItem("usuario-autenticado", "1");
            //pegar no valor e atribuir para rota de navegação
            this.router.navigate([this.returnUrl]);
        }
        */
    }

   
}
