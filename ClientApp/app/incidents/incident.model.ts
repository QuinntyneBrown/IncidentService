import { Base } from "./base.model";

export class Incident extends Base { 

    public incidentId:any;
    
    public name:string;

    public static fromJSON(data: any): Incident {

        let incident = new Incident();

        incident.incidentId = data.incidentId;

        incident.name = data.name;

        return incident;
    }
}
