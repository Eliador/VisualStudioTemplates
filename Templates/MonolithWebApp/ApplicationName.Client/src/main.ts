import "core-js";
import { platformBrowserDynamic } from '@angular/platform-browser-dynamic';
import { AppModule } from './app/App.module';

const platform = platformBrowserDynamic();
platform.bootstrapModule(AppModule);

