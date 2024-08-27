import { useState } from 'react';
import { ICollapsibleProps } from '../interfaces/ICollapsibleProps';

const Collapsible = ({ title , children} : ICollapsibleProps)  => {
    const [isOpen, setIsOpen] = useState(false);

    const toggleCollapse = () => {
        setIsOpen(!isOpen);
    };

    return (
        <div className="collapsible-item">
            <div 
                className="cursor-pointer flex justify-between items-center border-b pb-2 mb-2"
                onClick={toggleCollapse}
            >
                <h2 className="text-xl font-semibold">{!isOpen ? title : ''}</h2>
                <span>{isOpen ? 'Collapse' : 'Expand'}</span>
            </div>
            {isOpen && <div className="collapsible-content">{children}</div>}
        </div>
    );
};

export default Collapsible;