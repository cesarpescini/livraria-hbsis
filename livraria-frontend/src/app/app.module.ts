import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { HttpClientModule } from '@angular/common/http';
import { FormsModule } from '@angular/forms';

import { AppComponent } from './app.component';
import { LivrariaListagemComponent } from './livraria-listagem/livraria-listagem.component';
import { LivrariaService } from './livraria.service';
import { RouterModule } from '@angular/router';
import { appRoutes } from './routerConfig';
import { LivroCreateComponent } from './livro-create/livro-create.component';


@NgModule({
  declarations: [
    AppComponent,
    LivrariaListagemComponent,
    LivroCreateComponent
  ],
  imports: [
    BrowserModule,
    HttpClientModule,
    RouterModule.forRoot(appRoutes),
    FormsModule
  ],
  providers: [ LivrariaService ],
  bootstrap: [AppComponent]
})
export class AppModule { }