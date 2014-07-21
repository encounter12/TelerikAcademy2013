define(["jquery", "handlebars"],function($, handlebars){
    var comboBox = (function(items){
        var isCollapsed = true;

        function render (template) {
            var personTemplate = Handlebars.compile(template),
                len, i;

            var $docFragment = $(document.createDocumentFragment());

            for(i = 0, len = items.length; i < len; i++ ){
                var $currentPerson = $(personTemplate(items[i]));
                if(i == 0){
                    $currentPerson.addClass('current');
                }
                $currentPerson.on('click', expandCollapse);
                $docFragment.append($currentPerson);
            }
            return $docFragment;
        }

        function expandCollapse(){
            $this = $(this);
            $container = $this.parent();

            if(isCollapsed){
                $container.find('.person-item').addClass('expand');
                isCollapsed = false;
                return;
            }
            $container.find('.person-item.current').removeClass('current');
            $this.addClass('current');
            $container.find('.person-item').removeClass('expand');
            isCollapsed = true;
        }

        return {
            render : render
        }
    });

    return {
        comboBox: comboBox
    }
})
