export interface IProduct {
    productID: number;
    productName: string;
    categoryID: number;
    supplierID: number;
    quantityPerUnit: string;
    unitPrice: number;
    unitsInStock: number;
    unitsOnOrder: number;
    reorderLevel: number;
    discontinued: boolean;
}