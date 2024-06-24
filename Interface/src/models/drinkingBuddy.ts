export class DrinkingBuddy{
    public id: string;
    public from: string;
    public to: string;

    constructor(id: string, from: string, to: string) {
        this.from = from;
        this.to = to;
        this.id = id
    }
}