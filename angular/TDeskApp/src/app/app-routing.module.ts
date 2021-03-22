import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { LoginComponent } from './login/login.component';
import { VideoCallComponent } from './pages/video-call/video-call.component';
import { WelcomeComponent } from './pages/welcome/welcome.component';
import { AuthLoginService } from './services/authloginservice.service';

const routes: Routes = [
  // { path: '', pathMatch: 'full', redirectTo: '/welcome' },
  { path: '', pathMatch: 'full', redirectTo: '/login' },
  // { path: 'welcome', loadChildren: () => import('./pages/welcome/welcome.module').then(m => m.WelcomeModule),
  //     canActivate:[AuthLoginService],
  //     canLoad:[AuthLoginService] },
  { path: 'login', component: LoginComponent},
  {
    path: 'welcome',
    canActivate: [AuthLoginService],
    component: WelcomeComponent,
    children: [

    ],
  },
  { path: 'video', canActivate: [AuthLoginService], component: VideoCallComponent},
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
