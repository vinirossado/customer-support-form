import { ElementRef, Injectable } from '@angular/core';
import { TestBed } from '@angular/core/testing';
import { TextareaAutoresizeDirective } from './textarea-autoresize.directive';

@Injectable()
export class MockElementRef {
    nativeElement!: {}
}

describe('TextareaAutoresizeDirective', () => {
    let testBedElementRefService: ElementRef;
    beforeEach(() => {
        TestBed.configureTestingModule({
            declarations: [TextareaAutoresizeDirective],
            providers: [{ provide: ElementRef, useValue: new MockElementRef() }]
        })
        testBedElementRefService = TestBed.inject(ElementRef);
    });

    it('should create an instance', () => {
        const directive = new TextareaAutoresizeDirective(testBedElementRefService);
        expect(directive).toBeTruthy();
    });
});
