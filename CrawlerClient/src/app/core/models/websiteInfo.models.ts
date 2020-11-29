export class WebsiteInfo {
  constructor(
    public uri: string,
    public images: ImageInfo[]
  ) { }

  static Adapt(model: any): WebsiteInfo {
    const images = model.images as ImageInfo[];

    return new WebsiteInfo(model.uri, images);
  }
}

export class ImageInfo {
  constructor(
    public uri: string,
  ) { }

  static Adapt(model: any): ImageInfo {
    return new ImageInfo(model.uri);
  }
}

export interface CrawlWebsiteForm {
  uri: string;
}
