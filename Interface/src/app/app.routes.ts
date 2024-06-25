import { Routes } from '@angular/router';

export const routes: Routes = [
    {path: '', loadComponent: () => import('./rules/rules.component').then(m => m.RulesComponent)}, // Default landing page
    // { path: '**', redirectTo: '' },
    {path: 'Ace', loadComponent: () => import('./gameInstances/switch-direction/switch-direction.component').then(m => m.SwitchDirectionComponent)},
    {path: 'King', loadComponent: () => import('./gameInstances/jackpot/jackpot.component').then(m => m.JackpotComponent)},
    {path: 'Queen', loadComponent: () => import('./gameInstances/onevone/onevone.component').then(m => m.OnevoneComponent)},
    {path: 'Jack', loadComponent: () => import('./gameInstances/drinking-buddy/drinking-buddy.component').then(m => m.DrinkingBuddyComponent)},
    {path: '10', loadComponent: () => import('./gameInstances/categories/categories.component').then(m => m.CategoriesComponent)},
    {path: '9', loadComponent: () => import('./gameInstances/random-drink/random-drink.component').then(m => m.RandomDrinkComponent)},
    {path: '8', loadComponent: () => import('./gameInstances/random-amount/random-amount.component').then(m => m.RandomAmountComponent)},
    {path: '7', loadComponent: () => import('./gameInstances/fuck-neighbors/fuck-neighbors.component').then(m => m.FuckNeighborsComponent)},
    {path: '6', loadComponent: () => import('./gameInstances/loveneighbors/loveneighbors.component').then(m => m.LoveneighborsComponent)},
    {path: '5', loadComponent: () => import('./gameInstances/piss/piss.component').then(m => m.PissComponent)},
    {path: '4', loadComponent: () => import('./gameInstances/notalking/notalking.component').then(m => m.NotalkingComponent)},
    {path: '3', loadComponent: () => import('./gameInstances/chug/chug.component').then(m => m.ChugComponent)},
    {path: '2', loadComponent: () => import('./gameInstances/doubledown/doubledown.component').then(m => m.DoubledownComponent)},
    {path: 'Joker', loadComponent: () => import('./gameInstances/wildcard/wildcard.component').then(m => m.WildcardComponent)},
];
