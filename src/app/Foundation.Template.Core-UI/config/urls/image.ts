export const IMAGE_THUMBNAIL_URL = (id: string) => `/api/v1/images/thumbnail/${encodeURIComponent(id)}`;
export const IMAGE_RAW_URL = (id: string) => `/api/v1/images/raw/${encodeURIComponent(id)}`;

export const IMAGE_FOUNDATION_RAW_URL = (id: string, token: string) => `/api/core/v1/images/raw/${encodeURIComponent(id)}?token=${token}`;