export interface IUserData {
    articles: [
        {
            id: number,
            is_user: string,
            title: string,
            text: string,
            subject: string,
            date_article: string
        }
    ],
    error: string
}