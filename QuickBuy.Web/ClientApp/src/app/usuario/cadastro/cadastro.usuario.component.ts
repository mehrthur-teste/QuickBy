import { Component, OnInit } from "@angular/core";
import { Usuarios } from "../../modelo/usuario";
import { UsuarioServico } from "../../../servicos/usuario/usuario.service";
@Component({
    selector: "cadastro-usuario",
    templateUrl: "./cadastro.usuario.component.html",
    styleUrls: ["./cadastro.usuario.component.css"]
})

export class CadastroUsuarioComponent implements OnInit{
    public usuario: Usuarios;
    public ativar_spinner: boolean;
    public mensagem: string;
    public usuarioCadastrado: boolean;

    constructor(private usuarioServico: UsuarioServico) {

    }

    ngOnInit():void {
        this.usuario = new Usuarios();
        
    }

    public cadastrar() {
        this.ativar_spinner = true;
        this.usuarioServico.cadastrarUsuario(this.usuario)
            .subscribe(
                usuarioJson => {
                    this.usuarioCadastrado = true;
                    this.mensagem = "";
                    this.ativar_spinner = false;
                },
                e => {
                    
                    this.mensagem = e.error;
                    this.ativar_spinner = false;
                }
            );
            
    }
}
