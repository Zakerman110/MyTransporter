export interface CommentDto {
    readonly id: number;
    readonly name: string;
    rate: number;
    readonly description: string;
    readonly date: string;
    readonly customerId: number;
    readonly orderId: number;
}