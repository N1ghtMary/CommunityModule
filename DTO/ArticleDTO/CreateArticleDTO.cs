using System.ComponentModel.DataAnnotations;

namespace DTO.ArticleDTO;

public class CreateArticleDTO
{
    //public int ArticleId { get; set; }
    [Required (ErrorMessage = "Поле \"Заголовок\" обязательно для заполнения")]
    public string Title { get; set; }
    [Required (ErrorMessage = "Поле \"Текст статтьи\" обязательно для заполнения")]
    public string ArticleText { get; set; }
    [Required (ErrorMessage = "Поле \"Дата публикации\" обязательно для заполнения")]
    [RegularExpression("[0-9]{4}-[0-9]{2}-[0-9]{2}",ErrorMessage = "Неверно введена дата публикации")]
    public DateTime ArticlePublicationDate { get; set; }
    [Required (ErrorMessage = "Поле \"Идентификатор пользователя\" обязательно для заполнения")]
    public int UserId { get; set; }
    [Required (ErrorMessage = "Поле \"Идентификатор группы\" обязательно для заполнения")]
    public int GroupId { get; set; }
    [Required (ErrorMessage = "Поле \"Просмотры\" обязательно для заполнения")]
    public int Views { get; set; }
}