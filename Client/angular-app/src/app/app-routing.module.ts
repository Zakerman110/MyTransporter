import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AuthGuard } from './auth/auth.guard';
import { AboutComponent } from './components/about/about.component';
import { AdminPanelOrderComponent } from './components/admin-panel-order/admin-panel-order.component';
import { AdminPanelComponent } from './components/admin-panel/admin-panel.component';
import { HomeComponent } from './components/home/home.component';
import { MyaccountComponent } from './components/myaccount/myaccount.component';
import { ServicesComponent } from './components/services/services.component';

const routes: Routes = [
  { 
    path: '',
    redirectTo: 'home',
    pathMatch: 'full' 
  },
  {
    path: 'home',
    component: HomeComponent
  },
  {
    path: 'about',
    component: AboutComponent
  },
  {
    path: 'services',
    component: ServicesComponent
  },
  {
    path: 'myaccount',
    component: MyaccountComponent,
    canActivate: [AuthGuard],
    data: {
      role: 'Customer'
    }
  },
  {
    path: 'admin-panel',
    component: AdminPanelComponent,
    canActivate: [AuthGuard],
    data: {
      role: 'Admin'
    },
    children: [
      { path: 'orders', component: AdminPanelOrderComponent }
    ]
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
