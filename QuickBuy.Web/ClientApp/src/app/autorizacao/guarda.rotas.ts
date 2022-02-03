import { Injectable } from '@angular/core';
import { Router, CanActivate, ActivatedRouteSnapshot, RouterStateSnapshot } from "@angular/router";
import { UsuarioServico } from '../../servicos/usuario/usuario.service';

@Injectable({
    //significa que vai ser publicada na raíz
    providedIn:'root'

})
export class GuardaRotas implements CanActivate {
    
    constructor(private router: Router, private usuarioServico :UsuarioServico) {
       
    }

    canActivate(route: ActivatedRouteSnapshot, state: RouterStateSnapshot): boolean {
       
        //colocar uma variável de autenticado para usar ela como verificação
   
        //se autenticado for igual a 1
        if (this.usuarioServico.usuario_autenticado()) {
 
            return true;
        }
        // alert(state.url);
        //se não for ele vai executar estas linhas debaixo
        this.router.navigate(['/entrar'], { queryParams: { returnUrl: state.url } });
        // se usuario autenticado retorne verdadeiro
        return false;
    }
    
}

