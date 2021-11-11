import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { MainPageComponent } from './final-pages/main-page/main-page.component';
import { UserPageComponent } from './final-pages/user-page/user-page.component';

const routes: Routes = [
  { path: '', component: MainPageComponent},
  { path: 'profile', component: UserPageComponent},
  // { path: '**', component: }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }

export const routingComponents = [MainPageComponent, UserPageComponent]
