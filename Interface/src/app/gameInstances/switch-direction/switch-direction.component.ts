import { Component, OnInit } from '@angular/core';
import { Player } from '../../../models/player';
import { FormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-switch-direction',
  standalone: true,
  imports: [
    FormsModule,
    CommonModule
  ],
  templateUrl: './switch-direction.component.html',
  styleUrl: './switch-direction.component.css'
})
export class SwitchDirectionComponent implements OnInit{
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

  async selectPlayer(player: Player, clockwise: boolean){
    await fetch(`https://localhost:5104/switchDirection?name=${player.name}&clockwise=${clockwise}`, {method: 'POST',})
    this.initData();
  }
}
