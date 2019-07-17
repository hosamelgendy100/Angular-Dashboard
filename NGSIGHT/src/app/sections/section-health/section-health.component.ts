import { Server } from './../../shared/server';
import { Component, OnInit } from '@angular/core';

const SAMPLE_SERVERS = [
  { id: 1, name: 'dev-web-1', isOnline: true },
  { id: 2, name: 'dev-mail-1', isOnline: false },
  { id: 3, name: 'prod-web-2', isOnline: true },
  { id: 4, name: 'prod-mail-2', isOnline: true }
];


@Component({
  selector: 'app-section-health',
  templateUrl: './section-health.component.html',
  styleUrls: ['./section-health.component.css']
})

export class SectionHealthComponent implements OnInit {
  servers: Server [] = SAMPLE_SERVERS;
  constructor() { }

  ngOnInit() {
  }

}
