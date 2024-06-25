import { Component, OnInit } from '@angular/core';
import { Player } from '../../../models/player';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';

@Component({
  selector: 'app-wildcard',
  standalone: true,
  imports: [
    FormsModule,
    CommonModule
  ],
  templateUrl: './wildcard.component.html',
  styleUrl: './wildcard.component.css'
})
export class WildcardComponent implements OnInit{
  players: Player[] = [];

  ngOnInit(): void {
      this.initData();
  }

  async initData(){
    const response =  await fetch(`https://localhost:5104/players`, {
      method: 'GET',
    });

    let playersRespo = await response.json();
    this.players = playersRespo;
  }

  async selectPlayer(player: Player, increment: boolean){
    await fetch(`https://localhost:5104/wildcard?name=${player.name}&increment=${increment}`, {method: 'POST',})
    this.initData();
  }

  headsOrTails(){    
    window.open('https://www.google.com/search?q=heads+or+tails&oq=heads+or+tails&gs_lcrp=EgZjaHJvbWUqDAgAEAAYQxiABBiKBTIMCAAQABhDGIAEGIoFMgcIARAAGIAEMgcIAhAAGIAEMgcIAxAAGIAEMgcIBBAAGIAEMgcIBRAAGIAEMgcIBhAAGIAEMgcIBxAAGIAE0gEIMTg0NWowajGoAgCwAgA&sourceid=chrome&ie=UTF-8', '_blank')?.focus();
  }
}