export class Player{
    public name: string;
    public difficulty: number;
    public totalDrinks: number;
    public isInRaffle: boolean;
    
    constructor(_name: string, _difficulty: number, _totalDrinks: number, _isInRaffle: boolean) {
        this.name = _name;
        this.difficulty = _difficulty;
        this.totalDrinks = _totalDrinks;
        this.isInRaffle = _isInRaffle;
    }
}