import { ISupplier } from './ISupplier';

export interface ISupplierListProps {
    suppliers: ISupplier[];
    onEdit: (supplierId: number) => void;
    onDelete: (supplierId: number) => void;
}
