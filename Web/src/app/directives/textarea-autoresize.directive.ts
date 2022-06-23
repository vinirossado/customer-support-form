import { Directive, ElementRef, HostListener } from '@angular/core';

@Directive({
    selector: '[appTextareaAutoresize]'
})
export class TextareaAutoresizeDirective {

    constructor(private _elementRef: ElementRef) {

    }

    @HostListener(':input')
    onInput() {
        this.resize();
    }

    ngOnInit() {
        if (this._elementRef.nativeElement.scrollHeight) {
            setTimeout(() => this.resize());
        }
    }

    resize() {
        this._elementRef.nativeElement.style.height = '0';
        this._elementRef.nativeElement.style.height = this._elementRef.nativeElement.scrollHeight + 'px';
    }
}
