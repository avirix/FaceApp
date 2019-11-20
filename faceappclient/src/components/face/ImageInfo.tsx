import React from 'react';

interface ImageInfoProps {
    data: any,
}

export const ImageInfo: React.FC<ImageInfoProps> = (props) => {
    return (
        <div>
            <p>{JSON.stringify(props.data)}</p>
        </div>
    );
}
