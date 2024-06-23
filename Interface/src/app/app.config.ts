import { ApplicationConfig, importProvidersFrom, provideZoneChangeDetection } from '@angular/core';
import { provideRouter } from '@angular/router';
import { JwtModule } from '@auth0/angular-jwt';

import { routes } from './app.routes';
import { provideHttpClient, withInterceptorsFromDi } from '@angular/common/http';

export const appConfig: ApplicationConfig = {
  providers: [
    provideZoneChangeDetection({ eventCoalescing: true }), 
    provideRouter(routes),
    importProvidersFrom(
      JwtModule.forRoot({
          config: {
              tokenGetter: getToken,
              allowedDomains: ["localhost:5104"],
              disallowedRoutes: [],
          },
      }),
  ),
  provideHttpClient(
      withInterceptorsFromDi()
  ),
  ]
};

export function getToken(){
  let jsonToken = localStorage.getItem('token');
  if(!jsonToken){
    alert('Currently not logged in. Please log in.')
    location.href = '/login';
    return '';
  }
  const token = JSON.parse(jsonToken);
  return token.accessToken;
}
