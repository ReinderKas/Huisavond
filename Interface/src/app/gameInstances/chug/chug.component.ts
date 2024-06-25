import { CommonModule } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { Player } from '../../../models/player';

@Component({
  selector: 'app-chug',
  standalone: true,
  imports: [
    FormsModule,
    CommonModule
  ],
  templateUrl: './chug.component.html',
  styleUrl: './chug.component.css'
})
export class ChugComponent implements OnInit {
  players: Player[] = [];

  ngOnInit(): void {
      this.initData();
      window.open('https://www.google.com/search?q=google+countdown+timer+30+seconds&sca_esv=0bc43c4c8dd2597c&sca_upv=1&sxsrf=ADLYWIJP7WWlOt9IFUXnF8tjt3J9nxHPRA%3A1719319935122&ei=f716ZrKHB_z1i-gP-dPt0Ac&ved=0ahUKEwjywvPv5faGAxX8-gIHHflpG3oQ4dUDCBA&uact=5&oq=google+countdown+timer+30+seconds&gs_lp=Egxnd3Mtd2l6LXNlcnAiIWdvb2dsZSBjb3VudGRvd24gdGltZXIgMzAgc2Vjb25kczIGEAAYFhgeMgYQABgWGB4yCxAAGIAEGIYDGIoFMgsQABiABBiGAxiKBTILEAAYgAQYhgMYigUyCxAAGIAEGIYDGIoFMggQABiABBiiBDIIEAAYgAQYogQyCBAAGIAEGKIEMggQABiABBiiBEjxF1DmBVjhFXAEeAGQAQCYAWOgAdkHqgECMTS4AQPIAQD4AQGYAhKgAoUIwgIKEAAYsAMY1gQYR8ICBRAAGIAEwgIIEAAYFhgKGB7CAgUQIRigAcICBBAhGBXCAggQABgIGA0YHpgDAIgGAZAGB5IHBDE3LjGgB91i&sclient=gws-wiz-serp', '_blank')?.focus();
  }

  async initData(){
    const response =  await fetch(`https://localhost:5104/players`, {
      method: 'GET',
    });

    let playersRespo = await response.json();
    this.players = playersRespo;
  }

  async selectPlayer(player: Player, success: boolean){
    await fetch(`https://localhost:5104/chug?name=${player.name}&success=${success}`, {method: 'POST',})
    this.initData();

    let response2 = await fetch(`https://localhost:5104/drinkingBuddy?name=${player.name}&skip=${player.name}`, {method: 'PUT',})
    this.initData();

    let playersRespo = await response2.text();
    alert(playersRespo);
  }
}
