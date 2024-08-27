import { toast } from 'react-toastify';

export const notifyCreate = (entityName = '') => {
  toast.success(`${entityName} created successfully!`, {
    position: "top-right",
    autoClose: 3000, // 3 seconds
  });
};

export const notifyError = (entityName = '') => {
  toast.error(`Failed to process ${entityName}!`, {
    position: "top-right",
    autoClose: 3000,
  });
};

export const notifyUpdate = (entityName = '') => {
  toast.info(`${entityName} updated successfully!`, {
    position: "top-right",
    autoClose: 3000,
  });
};

export const notifyDelete = (entityName = '') => {
  toast.warning(`${entityName} deleted successfully!`, {
    position: "top-right",
    autoClose: 3000,
  });
};