var id;

$(document).on('click', '.buy', (e) => {
	var partialDiv = $('#partialDiv'),
		mainDiv = $('#mainDiv');
		header = $('header');

	id = $(e.target).attr('data-id');

	$.ajax({
		type: 'GET',
		url: '/Home/BuyTicketModal',
		data: { id: id },
		success: function (responce) {
			partialDiv
				.html(responce)
				.addClass('animate');
			mainDiv
				.addClass('blurring');
			header
				.addClass('blurring');
		},
		error: function () {
			console.log('failed');
		}
	});
});

$('#select').change((e) => {
	var selectedVal = $(e.target).val(),
		totalAmount = $('.totalAmount');
	$.ajax({
		type: 'GET',
		url: '/Home/TotalAmount',
		data: {
			selectedVal: selectedVal,
			id: id
		},
		success: function (responce) {
			totalAmount.val(responce);
		},
		error: function () {
			console.log('failed');
		}
	});
});

$(window).click((e) => {
	var buttonBuy = $('#buy'),
		partialDiv = $('#partialDiv'),
		mainDiv = $('#mainDiv');
		header = $('header');

	if (partialDiv.has(e.target).length == 0 && !partialDiv.is(e.target) && !buttonBuy.is(e.target)) {
		partialDiv
			.html('')
			.removeClass('animate');
		mainDiv
			.removeClass('blurring');
		header
			.removeClass('blurring');
	}
});