import { Component, OnInit, EventEmitter, Output, ElementRef, Input, ViewChild } from '@angular/core';

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.css']
})
export class HeaderComponent implements OnInit {
  @Output() sidenavToggle = new EventEmitter<void>();
  @ViewChild('matButton') matButton;
  constructor() { }

  ngOnInit(): void {
  }

  onToggleSidenav() {
    this.matButton._elementRef.nativeElement.blur();
    this.sidenavToggle.emit();

  }

}
