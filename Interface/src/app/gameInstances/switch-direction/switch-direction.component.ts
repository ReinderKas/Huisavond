import { Component } from '@angular/core';
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
export class SwitchDirectionComponent {
  players: Player[] = [];

  async initData(){
    const response =  await fetch(`https://localhost:5104/players`, {
      method: 'GET',
    });

    let playersRespo = await response.json();
    this.players = playersRespo;
  }

  async selectPlayer(player: Player){
    await fetch(`https://localhost:5104/switchdirection/${player.name}`, {method: 'POST',})
  }
}
