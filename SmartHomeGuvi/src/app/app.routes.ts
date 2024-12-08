import { Routes } from '@angular/router';
import { LoginComponent } from './login/login.component';
import { UserComponent } from './user/user.component';
import { DashboardComponent } from './dashboard/dashboard.component';
import { DevicesComponent } from './devices/devices.component';
import { AutomationComponent } from './automation/automation.component';
import { AddActivationComponent } from './add-activation/add-activation.component';
import { UsageReportComponent } from './usage-report/usage-report.component';
import { NotificationsComponent } from './notifications/notifications.component';
import { HomeComponent } from './home/home.component';
import { TechHomeComponent } from './tech-home/tech-home.component';
import { AdminstratorComponent } from './adminstrator/adminstrator.component';
import { SendMaintenanceComponent } from './send-maintenance/send-maintenance.component';
import { MaintenanceListComponent } from './maintenance-list/maintenance-list.component';
import { UserListComponent } from './user-list/user-list.component';
import { TechRoomsComponent } from './tech-rooms/tech-rooms.component';
import { GetDiagReportComponent } from './get-diag-report/get-diag-report.component';
import { GlobalAutomationComponent } from './global-automation/global-automation.component';
import { AdminHomeComponent } from './admin-home/admin-home.component';
import { UserProfileComponent } from './user-profile/user-profile.component';
export const routes: Routes = [
    { path: 'home', component: HomeComponent}, 
    { path: 'login', component: LoginComponent },
    { path: 'register', component: UserComponent },
    { path: 'dashboard', component: DashboardComponent },
    { path: 'add-device', component: DevicesComponent },
    { path: 'automations', component: AutomationComponent }, 
    { path: 'add-activation', component: AddActivationComponent}, 
    { path: 'usage-report', component: UsageReportComponent}, 
    { path: 'notifications', component: NotificationsComponent}, 
    { path: 'tech-home', component: TechHomeComponent}, 
    { path: 'administrator', component: AdminstratorComponent}, 
    { path: 'send-maintenance', component: SendMaintenanceComponent}, 
    { path: 'maintain-List', component:MaintenanceListComponent},
    { path: 'UserList', component:UserListComponent},
    { path: 'tech-rooms', component:TechRoomsComponent},
    { path: 'GetDiagReport', component:GetDiagReportComponent},
    { path: 'global-automations', component: GlobalAutomationComponent },
    { path: 'admin-home', component: AdminHomeComponent},
    { path: 'user-profile', component: UserProfileComponent},
    
];
