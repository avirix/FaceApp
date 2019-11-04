import React from 'react';

interface ImageInfoProps {
    data: any,
}

const ImageInfo: React.FC<ImageInfoProps> = (props) => {
    return (
        <div>
            <p>{JSON.stringify(props.data)}</p>
        </div>
    );
}

export default ImageInfo;