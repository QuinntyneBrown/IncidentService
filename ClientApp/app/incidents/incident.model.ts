export class Incident  { 

    public id:any;
    
    public name:string;

    public static fromJSON(data: any): Incident {

        let incident = new Incident();

        incident.id = data.id;

        incident.name = data.name;

        return incident;
    }
}
