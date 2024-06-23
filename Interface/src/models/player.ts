export class Player{
    public name: string;
    public difficulty: number;
    public totalDrinks: number;
    
    constructor(_name: string, _difficulty: number, _totalDrinks: number) {
        this.name = _name;
        this.difficulty = _difficulty;
        this.totalDrinks = _totalDrinks;
    }
}