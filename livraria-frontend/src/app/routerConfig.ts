import { Routes } from '@angular/router';
import { LivrariaListagemComponent } from './livraria-listagem/livraria-listagem.component';
import { LivroCreateComponent } from './livro-create/livro-create.component';

export const appRoutes: Routes = [
    {
        path:'livro',
        component: LivrariaListagemComponent
    },
    {
        path:'',
        redirectTo: 'livro',
        pathMatch: 'full'
    },
    {
        path:'livro/create',
        component: LivroCreateComponent
    },
    {
        path:'livro/edit/:id',
        component: LivroCreateComponent
    },
    {
        path:'livro/delete/:id',
        component: LivroCreateComponent,
        data: {'action' : 'delete' }
    }
  ];