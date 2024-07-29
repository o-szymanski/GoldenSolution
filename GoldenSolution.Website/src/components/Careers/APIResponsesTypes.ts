export interface ICareerRecord {
  id: number | string;
  title: string;
  description: string;
  location: string;
  tags?: string[];
  salary?: string;
  contact?: string;
}

export interface ICareerAPIResponse {
  careers: ICareerRecord[];
}

export interface ICareerLocation {
  id: number | string;
  name: string;
}

export interface ICareerLocationsAPIResponse {
  locations: ICareerLocation[];
}
