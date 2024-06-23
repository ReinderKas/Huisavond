import { Routes } from '@angular/router';

export const routes: Routes = [
    {path: '', loadComponent: () => import('./rules/rules.component').then(m => m.RulesComponent)}, // Default landing page
    // { path: '**', redirectTo: '' },
    {path: 'jackpot', loadComponent: () => import('./gameInstances/jackpot/jackpot.component').then(m => m.JackpotComponent)},
    {path: 'drinkingBuddy', loadComponent: () => import('./gameInstances/drinking-buddy/drinking-buddy.component').then(m => m.DrinkingBuddyComponent)}
];
