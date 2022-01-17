import { Component } from '@angular/core';

@Component({
    selector: "app",
    templateUrl: "./App.component.html",
    styleUrls: [ "./App.component.scss" ]
})
export class AppComponent {
    constructor() {}

    public get Name(): string { return "Citizen"; };
}