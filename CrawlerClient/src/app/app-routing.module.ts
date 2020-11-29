import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { FormViewComponent } from './form-view/form-view.component';
import { ImagesViewComponent } from './images-view/images-view.component';
import { NavigationComponent } from './navigation/navigation.component';
import { WelcomePageComponent } from './welcome-page/welcome-page.component';


const routes: Routes = [
  {
    path: '',
    redirectTo: 'home/welcome',
    pathMatch: 'full'
  },
  {
    path: 'home',
    component: NavigationComponent,
    children: [
      {
        path: 'welcome',
        component: WelcomePageComponent
      },
      {
        path: 'images',
        component: ImagesViewComponent
      },
      {
        path: 'form',
        component: FormViewComponent
      },
    ],
  },

];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
