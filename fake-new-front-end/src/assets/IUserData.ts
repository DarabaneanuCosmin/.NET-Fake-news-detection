export interface IUserData {
    articles: [
        {
            id: number,
            title: string,
            text: string,
            subject: string,
            date_article: string
            is_fake: boolean
        }
    ],
    error: string
}