import { defineCustomElements } from "@dvs-design-system/components-js/loader";
import { bootstrapApplication } from '@angular/platform-browser';
import { appConfig } from './app/app.config';
import { App } from './app/app';

defineCustomElements(window, {
  resourcesUrl: "/assets/"
});
bootstrapApplication(App, appConfig)
  .catch((err) => console.error(err));
