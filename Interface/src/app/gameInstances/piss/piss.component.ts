import { CommonModule } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { Player } from '../../../models/player';

@Component({
  selector: 'app-piss',
  standalone: true,
  imports: [
    FormsModule,
    CommonModule
  ],
  templateUrl: './piss.component.html',
  styleUrl: './piss.component.css'
})
export class PissComponent implements OnInit{
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
    console.log(this.players)
  }

  async selectPlayer(player: Player){
    await fetch(`https://localhost:5104/piss?name=${player.name}`, {method: 'POST',})
    this.initData();
  }
}
