﻿namespace GeekShopping.CartAPI.ViewModels;

public class CartViewModel
{
    public CartHeaderViewModel CartHeader { get; set; }
    public IEnumerable<CartDetailViewModel> CartDetails { get; set; }
}
