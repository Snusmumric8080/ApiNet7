export interface BookCreate {
    title: string;
    author: string;
    year: number;
  }
  
  export interface BookRead {
    guid: string;
    title: string;
    author: string;
    year: number;
  }
  
  export interface BookUpdate {
    title: string;
    author: string;
    year: number;
  }