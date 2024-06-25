import { CommonModule } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { Player } from '../../../models/player';

@Component({
  selector: 'app-loveneighbors',
  standalone: true,
  imports: [
    FormsModule,
    CommonModule
  ],
  templateUrl: './loveneighbors.component.html',
  styleUrl: './loveneighbors.component.css'
})
export class LoveneighborsComponent implements OnInit {
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

  async selectPlayer(player: Player, increase: boolean){
    await fetch(`https://localhost:5104/loveNeighbors?name=${player.name}&increase=${increase}`, {method: 'POST',})
    this.initData();
  }
}